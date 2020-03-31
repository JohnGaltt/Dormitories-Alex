import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html'
})
export class StudentListComponent {
  public students: Students[];

  constructor(http: HttpClient) {
    http.get<Students[]>('https://localhost:44372/home').subscribe(result => {
      this.students = result;
    }, error => console.error(error));
  }
}

interface Students {
  id: string,
  name: string;
  email: string;
  dormitory: string;
  dormitoryId: string;
  room: string;
  roomId: string;
}
