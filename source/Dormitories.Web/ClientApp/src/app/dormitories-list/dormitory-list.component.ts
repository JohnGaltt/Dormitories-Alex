import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: "dormitory-list",
  templateUrl: "./dormitory-list.component.html"
})
export class DormitoryListComponent {
  public dormitories: Dormitory[];
  public dormitry: any;

  constructor(private http: HttpClient, private modalService: NgbModal) {
    http.get<Dormitory[]>("https://localhost:44372/dormitories").subscribe(
      result => {
        this.dormitories = result;
      },
      error => console.error(error)
    );
  }
  OnClick() {
    this.dormitry = { address: "address", name: "name" };
    
    this.http
      .post("https://localhost:44372/dormitories/create", this.dormitry)
      .subscribe(
        result => {
          console.log(result);
        },
        error => console.error(error)
      );
  }

  onSubmit() {
    console.log("Form was submitted!");
  }

  open(content) {
    this.modalService
      .open(content, { ariaLabelledBy: "modal-basic-title" })
      .result.then(result => {
        console.log("success");
      });
  }
}

interface Dormitory {
  name: string;
  address: string;
}
