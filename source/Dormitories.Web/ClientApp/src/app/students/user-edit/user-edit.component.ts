import { Component, OnInit } from "@angular/core";
import { User } from "src/app/models/user";
import { Subscription } from "rxjs";
import { UserService } from "src/app/services/student-service";
import { ActivatedRoute, Router } from "@angular/router";
import { AppToastService } from "src/app/shared/app-toast-service";
import { Dormitory } from "src/app/models/dormitory";
import { Room } from "src/app/models/room";
import { Role } from "src/app/models/role";
import { RolesService } from "src/app/services/roles.service";
import { DormitoryService } from "src/app/services/dormitory-service";
import { RoomService } from "src/app/services/room-service";

@Component({
  selector: "app-user-edit",
  templateUrl: "./user-edit.component.html",
  styleUrls: ["./user-edit.component.css"],
})
export class UserEditComponent implements OnInit {
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

  public dormitories: Dormitory[];
  public rooms: Room[];
  public roles: Role[];

  private sub: Subscription;
  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private router: Router,
    private toastService: AppToastService,
    private roleService: RolesService,
    private dormitoryService: DormitoryService,
    private roomService: RoomService
  ) {}
  getUser(id: number): void {
    this.userService.getUser(id).subscribe(
      (result) => {
        console.log(result);
        this.user = result;
        this.roomService.getRoomsByDormitoryId(this.user.dormitoryId).subscribe(
          (result) => {
            this.rooms = result;
          },
          (error) => console.error(error)
        );
      },
      (error) => console.error(error)
    );
  }

  onChange(dormitoryId: number) {
    this.roomService.getRoomsByDormitoryId(dormitoryId).subscribe(
      (result) => {
        this.rooms = result;
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

  onSubmit() {
    debugger;
    this.userService.updateUser(this.user).subscribe(
      (result) => {
        this.showSuccess("Користувача змінено");
        this.router.navigateByUrl("/student-list");
      },
      (error) => console.error(error)
    );
  }

  ngOnInit(): void {
    this.sub = this.route.paramMap.subscribe((params) => {
      const id = +params.get("id");

      this.roleService.getRoles().subscribe(
        (result) => {
          this.roles = result;
        },
        (error) => console.error(error)
      );
      this.dormitoryService.getDormitories().subscribe(
        (result) => {
          this.dormitories = result;
          this.getUser(id);
        },
        (error) => console.error(error)
      );
    });
  }
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
