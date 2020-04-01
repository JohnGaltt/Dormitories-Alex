import { Component, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "room-list",
  templateUrl: "./room-list.component.html"
})
export class RoomListComponent {
  public rooms: Room[];

  constructor(http: HttpClient) {
    http.get<Room[]>("https://localhost:44372/rooms").subscribe(
      result => {
        this.rooms = result;
      },
      error => console.error(error)
    );
  }
}

interface Room {
  id: string;
  name: string;
  email: string;
  dormitory: string;
  dormitoryId: string;
  room: string;
  roomId: string;
}
