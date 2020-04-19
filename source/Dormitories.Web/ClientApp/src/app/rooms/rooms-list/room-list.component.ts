import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Dormitory } from "src/app/models/dormitory";
import { Room } from "src/app/models/room";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { DormitoryService } from "src/app/services/dormitory-service";
import { RoomService } from "src/app/services/room-service";
import { AppToastService } from "src/app/shared/app-toast-service";

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
  public filteredRooms: Room[];
  public rooms: Room[];
  public dormitories: Dormitory[];
  page = 1;
  pageSize = 10;

  private _searchListFilter: string;
  get searchListFilter(): string {
    return this._searchListFilter;
  }
  set searchListFilter(value: string) {
    this._searchListFilter = value;
    this.filteredRooms =
      this.searchListFilter != ""
        ? this.performSearch(this.searchListFilter)
        : this.rooms;
  }

  constructor(
    http: HttpClient,
    private modalService: NgbModal,
    private dormitoryService: DormitoryService,
    private roomService: RoomService,
    private toastService: AppToastService
  ) {}

  getRooms() {
    this.roomService.getRooms().subscribe(
      (result) => {
        this.rooms = result;
        this.filteredRooms = this.rooms;
      },
      (error) => console.error(error)
    );
  }

  performSearch(value: string) {
    value = value.toLocaleLowerCase();
    return this.rooms.filter(
      (room: Room) => room.name.toLocaleLowerCase().indexOf(value) !== -1
    );
  }

  create() {
    this.roomService.createRoom(this.room).subscribe(
      (result) => {
        this.showSuccess("Кімната успішно створена!");
        this.getRooms();
        this.modalService.dismissAll();
      },
      (error) => console.error(error)
    );
  }

  onRemoveElement(elementId: number): void {
    this.roomService.deleteRoom(elementId).subscribe(
      (result) => {
        this.getRooms();
        this.showSuccess("Кімнату видалено");
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
