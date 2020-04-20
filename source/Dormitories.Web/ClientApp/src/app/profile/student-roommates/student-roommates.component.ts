import { Component, OnInit } from "@angular/core";
import { User } from "src/app/models/user";
import { UserService } from "src/app/services/student-service";
import { OpenIdConnectService } from "src/app/shared/open-id-connect.service";

@Component({
  selector: "app-student-roommates",
  templateUrl: "./student-roommates.component.html",
  styleUrls: ["./student-roommates.component.css"],
})
export class StudentRoommatesComponent implements OnInit {
  constructor(
    private userService: UserService,
    private openIdConnectService: OpenIdConnectService
  ) {}
  page = 1;
  pageSize = 10;
  roommates: User[];
  filteredRoommates: User[];

  private _searchListFilter: string;
  get searchListFilter(): string {
    return this._searchListFilter;
  }
  set searchListFilter(value: string) {
    this._searchListFilter = value;
    this.filteredRoommates =
      this.searchListFilter != ""
        ? this.performSearch(this.searchListFilter)
        : this.roommates;
  }

  performSearch(value: string) {
    value = value.toLocaleLowerCase();
    return this.roommates.filter(
      (user: User) => user.name.toLocaleLowerCase().indexOf(value) !== -1
    );
  }

  getRoommates() {
    debugger;
    var id = +this.openIdConnectService.user.profile.sub;
    this.userService.getRoommates(id).subscribe(
      (result) => {
        this.roommates = result;
        this.filteredRoommates = this.roommates;
      },
      (error) => console.error(error)
    );
  }
  ngOnInit() {
    this.getRoommates();
  }
}
