import { Component, OnInit } from "@angular/core";
import {
  StudentRequest,
  StudentRequestWithUser,
  RequestTypes,
} from "src/app/models/request";
import { RequestService } from "src/app/services/request.service";

@Component({
  selector: "app-requests-list",
  templateUrl: "./requests-list.component.html",
  styleUrls: ["./requests-list.component.css"],
})
export class RequestsListComponent implements OnInit {
  page = 1;
  pageSize = 10;
  RequestTypes = RequestTypes;
  requests: StudentRequestWithUser[];
  filteredRequests: StudentRequestWithUser[];
  public errorMessage: any;
  constructor(private requestService: RequestService) {}

  private _searchListFilter: string;
  get searchListFilter(): string {
    return this._searchListFilter;
  }
  set searchListFilter(value: string) {
    this._searchListFilter = value;
    this.filteredRequests =
      this.searchListFilter != ""
        ? this.performSearch(this.searchListFilter)
        : this.requests;
  }

  performSearch(value: string) {
    value = value.toLocaleLowerCase();
    return this.requests.filter(
      (request: StudentRequestWithUser) =>
        request.userName.toLocaleLowerCase().indexOf(value) !== -1
    );
  }

  getRequests() {
    this.requestService.getRequests().subscribe({
      next: (result) => {
        this.requests = result;
        this.filteredRequests = this.requests;
      },
      error: (err) => (this.errorMessage = err),
    });
  }

  ngOnInit() {
    this.getRequests();
  }
}
