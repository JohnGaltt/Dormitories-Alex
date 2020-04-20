import { Component, OnInit } from "@angular/core";
import { UserService } from "src/app/services/student-service";
import { OpenIdConnectService } from "src/app/shared/open-id-connect.service";
import { User, PartialUpdateUser } from "src/app/models/user";
import { AppToastService } from "src/app/shared/app-toast-service";
import { Image } from "@ks89/angular-modal-gallery";

@Component({
  selector: "app-student-profile-component",
  templateUrl: "./student-profile-component.component.html",
  styleUrls: ["./student-profile-component.component.css"],
})
export class StudentProfileComponentComponent implements OnInit {
  constructor(
    private userService: UserService,
    private openIdConnectService: OpenIdConnectService,
    private toastService: AppToastService
  ) {}

  public updateUser: PartialUpdateUser = {
    id: 0,
  };
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
