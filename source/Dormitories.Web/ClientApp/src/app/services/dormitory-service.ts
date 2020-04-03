import { Injectable } from "@angular/core";
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from "@angular/common/http";

import { Dormitory } from "../models/dormitory";
import { Observable, throwError } from "rxjs";
import { catchError, tap } from "rxjs/operators";
@Injectable({
  providedIn: "root",
})
export class DormitoryService {
  constructor(private http: HttpClient) {}
  getDormitories(): Observable<Dormitory[]> {
    return this.http
      .get<Dormitory[]>("https://localhost:44372/dormitories")
      .pipe(
        tap((data) => console.log("All: " + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getDormitory(id: number): Observable<Dormitory> {
    debugger;
    return this.http
      .get<Dormitory>(`https://localhost:44372/dormitories/${id}`)
      .pipe(
        tap((data) => console.log("All: " + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  createDormitory(dormitory: Dormitory): Observable<Dormitory> {
    return this.http
      .post<Dormitory>("https://localhost:44372/dormitories/create", dormitory)
      .pipe(
        tap((data) => console.log("All: " + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  updateDormitory(dormitory: Dormitory): Observable<Dormitory> {
    const headers = new HttpHeaders({ "Content-Type": "application/json" });
    return this.http
      .put<Dormitory>(
        `https://localhost:44372/dormitories/${dormitory.id}`,
        dormitory,
        {
          headers: headers,
        }
      )
      .pipe(
        tap((data) => console.log("All: " + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  deleteDormitory(id: number): Observable<{}> {
    return this.http
      .delete<{}>(`https://localhost:44372/dormitories/${id}`)
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
