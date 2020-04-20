import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { tap, catchError } from "rxjs/operators";
import { StudentRequest, StudentRequestWithUser } from "../models/request";

@Injectable({
  providedIn: "root",
})
export class RequestService {
  constructor(private http: HttpClient) {}

  getRequests(): Observable<StudentRequestWithUser[]> {
    return this.http
      .get<StudentRequestWithUser[]>("https://localhost:44372/requests")
      .pipe(
        tap((data) => console.log("All: " + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  createRequest(request: StudentRequest): Observable<StudentRequest> {
    return this.http
      .post<StudentRequest>("https://localhost:44372/requests", request)
      .pipe(
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
