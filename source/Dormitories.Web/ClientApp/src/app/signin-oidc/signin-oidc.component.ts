import { Component, OnInit } from "@angular/core";
import { OpenIdConnectService } from "../shared/open-id-connect.service";
import { Router } from "@angular/router";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-signin-oidc",
  templateUrl: "./signin-oidc.component.html",
  styleUrls: ["./signin-oidc.component.css"],
})
export class SigninOidcComponent implements OnInit {
  constructor(
    private openIdConenctService: OpenIdConnectService,
    private router: Router
  ) {}

  ngOnInit() {
    this.openIdConenctService.userLoaded$.subscribe((userLoaded) => {
      if (userLoaded) {
        this.router.navigate(["./"]);
      } else {
        if (!environment.production) {
          console.log("User was not loaded");
        }
      }
    });
    this.openIdConenctService.handleCallBack();
  }
}
