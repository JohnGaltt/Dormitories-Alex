import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Dormitory } from "src/app/models/dormitory";
import { Room } from "src/app/models/room";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { DormitoryService } from "src/app/services/dormitory-service";
import { RoomService } from "src/app/services/room-service";

@Component({
  selector: "room-list",
  templateUrl: "./room-list.component.html",
})
export class RoomListComponent implements OnInit {
  public room: Room = {
    id: 0,
    floor: "",
    name: "",
  };
  public rooms: Room[];
  public dormitories: Dormitory[];
  constructor(
    http: HttpClient,
    private modalService: NgbModal,
    private dormitoryService: DormitoryService,
    private roomService: RoomService
  ) {}

  getRooms() {
    this.roomService.getRooms().subscribe(
      (result) => {
        this.rooms = result;
      },
      (error) => console.error(error)
    );
  }

  onSubmit() {
    debugger;
    console.log(this.room);
    this.roomService.createRoom(this.room).subscribe(
      (result) => {
        this.getRooms();
        this.modalService.dismissAll();
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
    this.getRooms();
  }
}
