import { Injectable } from "@angular/core";
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from "@angular/common/http";

import { Room } from "../models/room";
import { Observable, throwError } from "rxjs";
import { catchError, tap } from "rxjs/operators";
@Injectable({
  providedIn: "root",
})
export class RoomService {
  constructor(private http: HttpClient) {}
  getRooms(): Observable<Room[]> {
    return this.http.get<Room[]>("https://localhost:44372/rooms").pipe(
      tap((data) => console.log("All: " + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  getRoom(id: number): Observable<Room> {
    debugger;
    return this.http.get<Room>(`https://localhost:44372/rooms/${id}`).pipe(
      tap((data) => console.log("All: " + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  createRoom(room: Room): Observable<Room> {
    return this.http
      .post<Room>("https://localhost:44372/rooms/create", room)
      .pipe(
        tap((data) => console.log("All: " + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getRoomsByDormitoryId(dormitoryId: number): Observable<Room[]> {
    return this.http
      .get<Room[]>(
        `https://localhost:44372/rooms/availablerooms/${dormitoryId}`
      )
      .pipe(
        tap((data) => console.log("All: " + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  updateRoom(room: Room): Observable<Room> {
    const headers = new HttpHeaders({ "Content-Type": "application/json" });
    return this.http
      .put<Room>(`https://localhost:44372/rooms/${room.id}`, room, {
        headers: headers,
      })
      .pipe(
        tap((data) => console.log("All: " + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  deleteRoom(id: number): Observable<{}> {
    return this.http.delete<{}>(`https://localhost:44372/rooms/${id}`).pipe(
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
