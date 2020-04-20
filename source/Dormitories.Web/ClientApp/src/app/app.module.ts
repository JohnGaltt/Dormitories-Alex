import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { StudentListComponent } from "./students/students-list/student-list.component";
import { VerticalComponent } from "./vertical-menu/vertical-menu.component";
import { RoomListComponent } from "./rooms/rooms-list/room-list.component";
import { DormitoryListComponent } from "./dormitories/dormitory-list.component";
import { DeleteButtonComponent } from "./user-actions/delete-button.component";
import { DormitoryEditComponent } from "./dormitories/dormitory-edit.component";
import { SigninOidcComponent } from "./signin-oidc/signin-oidc.component";
import { OpenIdConnectService } from "./shared/open-id-connect.service";
import { RequireAuthenticatedUserRouteGuardService } from "./shared/require-authenticated-user-route-guard.service";
import { AddAuthorizationHeaderInterceptor } from "./shared/add-authorization-header-interceptor";
import { StudentProfileComponentComponent } from "./profile/student-profile-component/student-profile-component.component";
import { AppToastsComponent } from "./app-toasts-component/app-toasts-component";
import { RoomEditComponent } from "./rooms/room-edit/room-edit.component";
import { UserEditComponent } from "./students/user-edit/user-edit.component";

import "hammerjs"; // Mandatory for angular-modal-gallery 3.x.x or greater (`npm i --save hammerjs`)
import "mousetrap"; // Mandatory for angular-modal-gallery 3.x.x or greater (`npm i --save mousetrap`)
import { GalleryModule } from "@ks89/angular-modal-gallery";
import { StudentRoommatesComponent } from "./profile/student-roommates/student-roommates.component";
import { RequestsListComponent } from "./requests/requests-list/requests-list.component"; //

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
    SigninOidcComponent,
    StudentProfileComponentComponent,
    AppToastsComponent,
    RoomEditComponent,
    UserEditComponent,
    StudentRoommatesComponent,
    RequestsListComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    GalleryModule.forRoot(),
    RouterModule.forRoot([
      {
        path: "",
        component: HomeComponent,
        pathMatch: "full",
        canActivate: [RequireAuthenticatedUserRouteGuardService],
      },
      {
        path: "student-list",
        component: StudentListComponent,
        canActivate: [RequireAuthenticatedUserRouteGuardService],
      },
      {
        path: "roommates-list",
        component: StudentRoommatesComponent,
        canActivate: [RequireAuthenticatedUserRouteGuardService],
      },
      {
        path: "room-list",
        component: RoomListComponent,
        canActivate: [RequireAuthenticatedUserRouteGuardService],
      },
      {
        path: "dormitory-list",
        component: DormitoryListComponent,
        canActivate: [RequireAuthenticatedUserRouteGuardService],
      },
      {
        path: "dormitory/:id/edit",
        component: DormitoryEditComponent,
        canActivate: [RequireAuthenticatedUserRouteGuardService],
      },
      {
        path: "room/:id/edit",
        component: RoomEditComponent,
        canActivate: [RequireAuthenticatedUserRouteGuardService],
      },
      {
        path: "user/:id/edit",
        component: UserEditComponent,
        canActivate: [RequireAuthenticatedUserRouteGuardService],
      },
      {
        path: "profile",
        component: StudentProfileComponentComponent,
        canActivate: [RequireAuthenticatedUserRouteGuardService],
      },
      {
        path: "app-requests-list",
        component: RequestsListComponent,
        canActivate: [RequireAuthenticatedUserRouteGuardService],
      },
      {
        path: "signin-oidc",
        component: SigninOidcComponent,
      },
    ]),
  ],
  providers: [
    OpenIdConnectService,
    RequireAuthenticatedUserRouteGuardService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AddAuthorizationHeaderInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
