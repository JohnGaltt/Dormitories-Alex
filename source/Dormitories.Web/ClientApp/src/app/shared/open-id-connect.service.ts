import { Injectable } from "@angular/core";
import { UserManager, User } from "oidc-client";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
export class OpenIdConnectService {
  private userManager: UserManager = new UserManager(
    environment.openIdConnectSettings
  );
  private currentUser: User;

  get userAvailable(): boolean {
    return this.currentUser != null;
  }

  get user(): User {
    return this.currentUser;
  }

  constructor() {
    this.userManager.clearStaleState();
    this.userManager.events.addUserLoaded((user) => {
      if (!environment.production) {
      }
      this.currentUser = user;
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
}
