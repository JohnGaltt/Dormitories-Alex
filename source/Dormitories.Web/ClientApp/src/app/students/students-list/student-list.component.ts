import { Component, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Student } from "src/app/models/student";
import { Dormitory } from "src/app/models/dormitory";
import { DormitoryService } from "src/app/services/dormitory-service";

@Component({
  selector: "app-student-list",
  templateUrl: "./student-list.component.html",
})
export class StudentListComponent {
  public student: Student = {
    id: 0,
    name: "",
    email: "",
    dormitory: { address: "", id: 0, name: "" },
    dormitoryId: 0,
    room: { name: "", id: 0, floor: "" },
    roomId: 0,
  };

  public students: Student[];
  public dormitories: Dormitory[];

  constructor(
    http: HttpClient,
    private modalService: NgbModal,
    private dormitoryService: DormitoryService
  ) {
    http.get<Student[]>("https://localhost:44372/students").subscribe(
      (result) => {
        this.students = result;
      },
      (error) => console.error(error)
    );
  }
  onChange(event) {
    
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
    debugger;
  }
}
