import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Dormitory } from "../models/dormitory";
import { DormitoryService } from "../services/dormitory-service";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { AppToastService } from "../shared/app-toast-service";

@Component({
  selector: "dormitory-list",
  templateUrl: "./dormitory-list.component.html",
})
export class DormitoryListComponent implements OnInit {
  page = 1;
  pageSize = 10;
  public filteredDormitories: Dormitory[];
  public dormitories: Dormitory[];
  public dormitory: Dormitory = {
    address: "",
    name: "",
    id: 0,
  };
  public errorMessage: any;
  public name: string;
  public address: string;
  private _searchListFilter: string;
  get searchListFilter(): string {
    return this._searchListFilter;
  }
  set searchListFilter(value: string) {
    this._searchListFilter = value;
    this.filteredDormitories =
      this.searchListFilter != ""
        ? this.performSearch(this.searchListFilter)
        : this.dormitories;
  }

  constructor(
    private http: HttpClient,
    private modalService: NgbModal,
    private dormitoryService: DormitoryService,
    private router: Router,
    private toastService: AppToastService
  ) {}

  OnCreate() {
    this.dormitoryService.createDormitory(this.dormitory).subscribe(
      (result) => {
        this.showSuccess("Гуртожиток створено");
        this.modalService.dismissAll();
        this.getDormitories();
      },
      (error) => console.error(error)
    );
  }

  onSubmit(form: NgForm) {
    console.log("Form was submitted!");
  }

  onRemoveElement(elementId: number): void {
    this.dormitoryService.deleteDormitory(elementId).subscribe(
      (result) => {
        this.getDormitories();
        this.showSuccess("Гуртожиток видалено");
      },
      (error) => console.error(error)
    );
  }

  onEditElement(dormitory: Dormitory): void {
    this.dormitoryService.updateDormitory(dormitory).subscribe(
      (result) => {
        this.showSuccess("Гуртожиток змінено");
        this.getDormitories();
      },
      (error) => console.error(error)
    );
  }

  performSearch(value: string) {
    value = value.toLocaleLowerCase();
    return this.dormitories.filter(
      (dormitry: Dormitory) =>
        dormitry.name.toLocaleLowerCase().indexOf(value) !== -1
    );
  }
  delete(): void {
    debugger;
    this.dormitoryService.deleteDormitory(this.dormitory.id).subscribe(
      (result) => {
        this.showSuccess("Гуртожиток був успішно видалений");
        this.router.navigate(["/dormitory-list"]);
      },
      (error) => console.error(error)
    );
  }
  open(content) {
    this.address = "";
    this.name = "";
    this.modalService
      .open(content, { ariaLabelledBy: "modal-basic-title" })
      .result.then((result) => {
        console.log("success");
      });
  }

  showSuccess(message: string) {
    this.toastService.show(message, {
      classname: "bg-success text-light",
      delay: 3000,
    });
  }

  getDormitories() {
    this.dormitoryService.getDormitories().subscribe({
      next: (result) => {
        this.dormitories = result;
        this.filteredDormitories = this.dormitories;
      },
      error: (err) => (this.errorMessage = err),
    });
  }
  ngOnInit(): void {
    this.getDormitories();
  }
}
