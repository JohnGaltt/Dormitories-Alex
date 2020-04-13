import { Component } from "@angular/core";
import { OpenIdConnectService } from "../shared/open-id-connect.service";

@Component({
  selector: "app-nav-menu",
  templateUrl: "./nav-menu.component.html",
  styleUrls: ["./nav-menu.component.css"],
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private openIdConnectService: OpenIdConnectService) {
    console.log(this.openIdConnectService);
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
