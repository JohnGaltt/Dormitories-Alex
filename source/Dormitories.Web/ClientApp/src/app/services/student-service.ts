import { Injectable } from "@angular/core";
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from "@angular/common/http";

import { Dormitory } from "../models/dormitory";
import { Observable, throwError } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { User, PartialUpdateUser } from "../models/user";
@Injectable({
  providedIn: "root",
})
export class UserService {
  constructor(private http: HttpClient) {}
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>("https://localhost:44372/users").pipe(
      tap((data) => console.log("All: " + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  getRoommates(id: number): Observable<User[]> {
    return this.http
      .get<User[]>(`https://localhost:44372/users/roommates/${id}`)
      .pipe(
        tap((data) => console.log("All: " + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getUser(id: number): Observable<User> {
    return this.http.get<User>(`https://localhost:44372/users/${id}`).pipe(
      tap((data) => console.log("All: " + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  getUserWithNames(id: number): Observable<User> {
    return this.http
      .get<User>(`https://localhost:44372/users/names/${id}`)
      .pipe(
        tap((data) => console.log("All: " + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  createUser(User: User): Observable<User> {
    return this.http
      .post<User>("https://localhost:44372/users/create", User)
      .pipe(
        tap((data) => console.log("All: " + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  updateUser(user: User): Observable<User> {
    const headers = new HttpHeaders({ "Content-Type": "application/json" });
    return this.http
      .put<User>(`https://localhost:44372/users/${user.id}`, user, {
        headers: headers,
      })
      .pipe(
        tap((data) => console.log("All: " + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  partialUpdate(user: PartialUpdateUser): Observable<PartialUpdateUser> {
    const headers = new HttpHeaders({ "Content-Type": "application/json" });
    return this.http
      .patch<PartialUpdateUser>(`https://localhost:44372/users`, user, {
        headers: headers,
      })
      .pipe(
        tap((data) => console.log("All: " + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  deleteUser(id: number): Observable<{}> {
    return this.http.delete<{}>(`https://localhost:44372/users/${id}`).pipe(
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
