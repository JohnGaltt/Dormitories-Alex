import { Injectable } from "@angular/core";
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from "@angular/common/http";

import { Dormitory } from "../models/dormitory";
import { Observable, throwError } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { Student } from "../models/student";
@Injectable({
  providedIn: "root",
})
export class StudentService {
  constructor(private http: HttpClient) {}
  getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>("https://localhost:44372/students").pipe(
      tap((data) => console.log("All: " + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  getStudent(id: number): Observable<Student> {
    return this.http
      .get<Student>(`https://localhost:44372/students/${id}`)
      .pipe(
        tap((data) => console.log("All: " + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  createStudent(student: Student): Observable<Student> {
    return this.http
      .post<Student>("https://localhost:44372/students/create", student)
      .pipe(
        tap((data) => console.log("All: " + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  updateStudent(student: Student): Observable<Student> {
    const headers = new HttpHeaders({ "Content-Type": "application/json" });
    return this.http
      .put<Student>(`https://localhost:44372/students/${student.id}`, student, {
        headers: headers,
      })
      .pipe(
        tap((data) => console.log("All: " + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  deleteStudent(id: number): Observable<{}> {
    return this.http.delete<{}>(`https://localhost:44372/students/${id}`).pipe(
      tap((data) => console.log("All: " + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse) {
    let errorMessage = "";
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Server returned code: ${err.status}, error message is ${err.message}`;
    }
    console.log(errorMessage);
    return throwError;
  }
}
