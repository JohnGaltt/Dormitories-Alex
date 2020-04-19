import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { User } from "src/app/models/user";
import { Dormitory } from "src/app/models/dormitory";
import { DormitoryService } from "src/app/services/dormitory-service";
import { RoomService } from "src/app/services/room-service";
import { Room } from "src/app/models/room";
import { UserService } from "src/app/services/student-service";
import { RolesService } from "src/app/services/roles.service";
import { Role } from "src/app/models/role";
import { Router } from "@angular/router";
import { AppToastService } from "src/app/shared/app-toast-service";

@Component({
  selector: "app-student-list",
  templateUrl: "./student-list.component.html",
})
export class StudentListComponent implements OnInit {
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
  page = 1;
  pageSize = 10;
  public filteredUsers: User[];
  public users: User[];
  public dormitories: Dormitory[];
  public rooms: Room[];
  public roles: Role[];

  private _searchListFilter: string;
  get searchListFilter(): string {
    return this._searchListFilter;
  }
  set searchListFilter(value: string) {
    this._searchListFilter = value;
    this.filteredUsers =
      this.searchListFilter != ""
        ? this.performSearch(this.searchListFilter)
        : this.users;
  }

  constructor(
    http: HttpClient,
    private modalService: NgbModal,
    private dormitoryService: DormitoryService,
    private roomService: RoomService,
    private userService: UserService,
    private roleService: RolesService,
    private router: Router,
    private toastService: AppToastService
  ) {}

  performSearch(value: string) {
    value = value.toLocaleLowerCase();
    return this.users.filter(
      (user: User) => user.name.toLocaleLowerCase().indexOf(value) !== -1
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
  getUsers() {
    this.userService.getUsers().subscribe(
      (result) => {
        this.users = result;
        this.filteredUsers = this.users;
      },
      (error) => console.error(error)
    );
  }
  onSubmit(): void {
    this.userService.createUser(this.user).subscribe(
      (result) => {
        this.showSuccess("Користувача додано");
        this.modalService.dismissAll();
        this.getUsers();
      },
      (error) => console.error(error)
    );
  }

  onRemoveElement(userId: number): void {
    this.userService.deleteUser(userId).subscribe(
      (result) => {
        this.showSuccess("Користувача видалено");
        this.getUsers();
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
    this.roleService.getRoles().subscribe(
      (result) => {
        this.roles = result;
      },
      (error) => console.error(error)
    );
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
  ngOnInit(): void {
    this.getUsers();
  }
}
