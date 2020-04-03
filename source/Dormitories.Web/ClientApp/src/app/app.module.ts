import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { NgbModule, NgbModalModule } from "@ng-bootstrap/ng-bootstrap";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { StudentListComponent } from "./students/students-list/student-list.component";
import { VerticalComponent } from "./vertical-menu/vertical-menu.component";
import { RoomListComponent } from "./rooms-list/room-list.component";
import { DormitoryListComponent } from "./dormitories/dormitory-list.component";
import { DeleteButtonComponent } from "./user-actions/delete-button.component";
import { DormitoryEditComponent } from "./dormitories/dormitory-edit.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    StudentListComponent,
    VerticalComponent,
    RoomListComponent,
    DormitoryListComponent,
    DeleteButtonComponent,
    DormitoryEditComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    NgbModalModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "student-list", component: StudentListComponent },
      { path: "room-list", component: RoomListComponent },
      { path: "dormitory-list", component: DormitoryListComponent },
      { path: "dormitory/:id/edit", component: DormitoryEditComponent },
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
