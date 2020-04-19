import { Component, OnInit } from "@angular/core";
import { Room } from "src/app/models/room";
import { Subscription } from "rxjs/internal/Subscription";
import { DormitoryService } from "src/app/services/dormitory-service";
import { ActivatedRoute, Router } from "@angular/router";
import { AppToastService } from "src/app/shared/app-toast-service";
import { RoomService } from "src/app/services/room-service";
import { Dormitory } from "src/app/models/dormitory";

@Component({
  selector: "app-room-edit",
  templateUrl: "./room-edit.component.html",
  styleUrls: ["./room-edit.component.css"],
})
export class RoomEditComponent implements OnInit {
  private room: Room;
  public dormitories: Dormitory[];
  private sub: Subscription;
  constructor(
    private dormitoryService: DormitoryService,
    private roomService: RoomService,
    private route: ActivatedRoute,
    private router: Router,
    private toastService: AppToastService
  ) {}
  getRoom(id: number): void {
    this.roomService.getRoom(id).subscribe(
      (result) => {
        debugger;
        this.room = result;
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

  update() {
    debugger;
    this.roomService.updateRoom(this.room).subscribe(
      (result) => {
        this.showSuccess("Гуртожиток змінено");
        this.router.navigateByUrl("/room-list");
      },
      (error) => console.error(error)
    );
  }

  ngOnInit(): void {
    this.sub = this.route.paramMap.subscribe((params) => {
      const id = +params.get("id");
      this.dormitoryService.getDormitories().subscribe(
        (result) => {
          this.dormitories = result;
          this.getRoom(id);
        },
        (error) => console.error(error)
      );
    });
  }
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
