import { Component } from "@angular/core";
import { OpenIdConnectService } from "../shared/open-id-connect.service";

@Component({
  selector: "app-vertical-menu",
  templateUrl: "./vertical-menu.component.html",
  styleUrls: ["./vertical-menu.component.css"],
})
export class VerticalComponent {
  constructor(private openIdConnectService: OpenIdConnectService) {}
}
