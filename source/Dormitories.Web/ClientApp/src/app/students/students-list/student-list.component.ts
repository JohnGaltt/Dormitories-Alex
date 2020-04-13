import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { User } from "src/app/models/user";
import { Dormitory } from "src/app/models/dormitory";
import { DormitoryService } from "src/app/services/dormitory-service";
import { RoomService } from "src/app/services/room-service";
import { Room } from "src/app/models/room";
import { UserService } from "src/app/services/student-service";

@Component({
  selector: "app-student-list",
  templateUrl: "./student-list.component.html",
})
export class StudentListComponent implements OnInit {
  public user: User = {
    id: 0,
    name: "",
    email: "",
    dormitoryAddress: "",
    dormitoryName: "",
    roomFloor: "",
    roomName: "",
  };

  public users: User[];
  public dormitories: Dormitory[];
  public rooms: Room[];

  constructor(
    http: HttpClient,
    private modalService: NgbModal,
    private dormitoryService: DormitoryService,
    private roomService: RoomService,
    private userService: UserService
  ) {}

  onChange(dormitoryId: number) {
    this.roomService.getRoomsByDormitoryId(dormitoryId).subscribe(
      (result) => {
        this.rooms = result;
      },
      (error) => console.error(error)
    );
  }
  getUsers() {
    this.userService.getUsers().subscribe(
      (result) => {
        this.users = result;
      },
      (error) => console.error(error)
    );
  }
  onSubmit(): void {
    this.userService.createUser(this.user).subscribe(
      (result) => {
        this.getUsers();
        this.modalService.dismissAll();
      },
      (error) => console.error(error)
    );
  }

  onRemoveElement(userId: number): void {
    debugger;
    this.userService.deleteUser(userId).subscribe(
      (result) => {
        this.getUsers();
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
          .result.then((result) => {});
      },
      (error) => console.error(error)
    );
  }
  ngOnInit(): void {
    this.getUsers();
  }
}
