import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Student } from "src/app/models/student";
import { Dormitory } from "src/app/models/dormitory";
import { DormitoryService } from "src/app/services/dormitory-service";
import { RoomService } from "src/app/services/room-service";
import { Room } from "src/app/models/room";
import { StudentService } from "src/app/services/student-service";

@Component({
  selector: "app-student-list",
  templateUrl: "./student-list.component.html",
})
export class StudentListComponent implements OnInit {
  public student: Student = {
    id: 0,
    name: "",
    email: "",
  };

  public students: Student[];
  public dormitories: Dormitory[];
  public rooms: Room[];

  constructor(
    http: HttpClient,
    private modalService: NgbModal,
    private dormitoryService: DormitoryService,
    private roomService: RoomService,
    private studentService: StudentService
  ) {}

  onChange(dormitoryId: number) {
    this.roomService.getRoomsByDormitoryId(dormitoryId).subscribe(
      (result) => {
        this.rooms = result;
      },
      (error) => console.error(error)
    );
  }
  getStudents() {
    this.studentService.getStudents().subscribe(
      (result) => {
        this.students = result;
      },
      (error) => console.error(error)
    );
  }
  onSubmit(): void {
    this.studentService.createStudent(this.student).subscribe(
      (result) => {
        this.getStudents();
        this.modalService.dismissAll();
      },
      (error) => console.error(error)
    );
  }

  onRemoveElement(studentId: number): void {
    debugger;
    this.studentService.deleteStudent(studentId).subscribe(
      (result) => {
        this.getStudents();
      },
      (error) => console.error(error)
    );
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
    this.getStudents();
  }
}
