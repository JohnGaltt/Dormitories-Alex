import { Component, OnInit } from "@angular/core";
import { UserService } from "src/app/services/student-service";
import { OpenIdConnectService } from "src/app/shared/open-id-connect.service";
import { User, PartialUpdateUser } from "src/app/models/user";
import { AppToastService } from "src/app/shared/app-toast-service";
import { Image } from "@ks89/angular-modal-gallery";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { DormitoryService } from "src/app/services/dormitory-service";
import { Dormitory } from "src/app/models/dormitory";
import { RoomService } from "src/app/services/room-service";
import { Room } from "src/app/models/room";
import { StudentRequest, RequestTypes } from "src/app/models/request";
import { RequestService } from "src/app/services/request.service";

@Component({
  selector: "app-student-profile-component",
  templateUrl: "./student-profile-component.component.html",
  styleUrls: ["./student-profile-component.component.css"],
})
export class StudentProfileComponentComponent implements OnInit {
  constructor(
    private userService: UserService,
    private openIdConnectService: OpenIdConnectService,
    private toastService: AppToastService,
    private modalService: NgbModal,
    private dormitoryService: DormitoryService,
    private roomService: RoomService,
    private requestService: RequestService
  ) {}

  public updateUser: PartialUpdateUser = {
    id: 0,
  };
  request: StudentRequest = {
    id: 0,
    userId: 0,
    reason: "",
  };
  RequestTypes = RequestTypes;
  images: Image[] = [
    new Image(0, {
      // modal
      img:
        "https://upload.wikimedia.org/wikipedia/uk/d/db/Lviv_Polytechnic_Campus_plan_lower_zone.jpg",
      extUrl: "http://www.google.com",
    }),
    new Image(1, {
      // modal
      img:
        "https://upload.wikimedia.org/wikipedia/uk/7/79/Lviv_Polytechnic_Campus_plan_upper_zone.jpg",
      extUrl: "http://www.google.com",
    }),
    //
  ];
  public dormitories: Dormitory[];
  public rooms: Room[];
  public user: User = {
    id: 0,
    name: "",
    email: "",
    dormitoryId: 0,
    roomId: 0,
    dormitoryAddress: "",
    dormitoryName: "",
    roomFloor: "",
    roomName: "",
    roleId: 0,
  };

  updatePayment() {
    this.userService.partialUpdate(this.updateUser).subscribe(
      (result) => {
        debugger;
        this.user.expireAt = result.expireAt;
        this.showSuccess("Оплата успішно проведена");
      },
      (error) => console.error(error)
    );
  }

  showSuccess(message: string) {
    this.toastService.show(message, {
      classname: "bg-success text-light",
      delay: 3000,
    });
  }

  openState(content) {
    this.modalService
      .open(content, { ariaLabelledBy: "modal-basic-title" })
      .result.then((result) => {
        console.log(result);
      });
  }

  openRoomModal(content) {
    this.roomService.getRoomsByDormitoryId(this.user.dormitoryId).subscribe(
      (result) => {
        this.rooms = result;
        this.modalService
          .open(content, { ariaLabelledBy: "modal-basic-title" })
          .result.then((result) => {
            console.log(result);
          });
      },
      (error) => console.error(error)
    );
  }

  onSubmitRequest(type: RequestTypes) {
    this.request.requestType = type;
    this.request.userId = this.user.id;
    this.requestService.createRequest(this.request).subscribe(
      (result) => {
        console.log(result);
        this.showSuccess("Заявку створено, дякуємо!");
        this.modalService.dismissAll();
        this.request.itemId = null;
        this.request.reason = "";
        this.request.requestType = null;
      },
      (error) => console.error(error)
    );
  }

  open(content) {
    this.dormitoryService.getDormitories().subscribe(
      (result) => {
        this.dormitories = result;
        this.modalService
          .open(content, { ariaLabelledBy: "modal-basic-title" })
          .result.then((result) => {
            console.log(result);
          });
      },
      (error) => console.error(error)
    );
  }
  getUserWithNames(id: number): void {
    this.userService.getUserWithNames(id).subscribe(
      (result) => {
        console.log(result);
        this.user = result;
        debugger;
        this.updateUser = {
          id: this.user.id,
          expireAt: this.user.expireAt,
        };
      },
      (error) => console.error(error)
    );
  }
  ngOnInit() {
    var userId = this.openIdConnectService.user.profile.sub;
    this.getUserWithNames(+userId);
  }
}
