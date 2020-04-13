import { Injectable } from "@angular/core";
import { UserManager, User } from "oidc-client";
import { environment } from "src/environments/environment";
import { ReplaySubject } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class OpenIdConnectService {
  private userManager: UserManager = new UserManager(
    environment.openIdConnectSettings
  );
  private currentUser: User;

  public get userAvailable(): boolean {
    return this.currentUser != null;
  }

  public get user(): User {
    return this.currentUser;
  }

  userLoaded$ = new ReplaySubject<boolean>(1);
  constructor() {
    this.userManager.clearStaleState();
    this.userManager.events.addUserLoaded((user) => {
      if (!environment.production) {
        console.log("User loaded", user);
      }
      this.currentUser = user;
      this.userLoaded$.next(true);
    });

    this.userManager.events.addUserUnloaded(() => {
      if (!environment.production) {
        console.log("User unloaded");
      }
      this.currentUser = null;
      this.userLoaded$.next(false);
    });
  }

  triggerSignIn() {
    this.userManager.signinRedirect().then(function (user) {
      console.log("Redirection after signin handled", user);
    });
  }

  handleCallBack() {
    this.userManager.signinRedirectCallback().then(function (user) {
      console.log("Callback after signin handled", user);
    });
  }

  triggerSignOut() {
    this.userManager.signoutRedirect().then(function (resp) {
      console.log("Redirection to sign out triggered", resp);
    });
  }
}
