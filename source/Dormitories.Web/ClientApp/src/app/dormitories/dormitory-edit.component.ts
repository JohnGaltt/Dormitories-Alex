import { OnInit, Component } from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Dormitory } from "../models/dormitory";
import { ActivatedRoute, Router } from "@angular/router";
import { DormitoryService } from "../services/dormitory-service";
import { Subscription } from "rxjs";

@Component({
  templateUrl: "./dormitory-edit.component.html",
})
export class DormitoryEditComponent implements OnInit {
  private dormitory: Dormitory;
  private sub: Subscription;
  constructor(
    private dormitoryService: DormitoryService,
    private route: ActivatedRoute,
    private router: Router
  ) {}
  getDormitory(id: number): void {
    this.dormitoryService.getDormitory(id).subscribe(
      (result) => {
        debugger;
        this.dormitory = result;
      },
      (error) => console.error(error)
    );
  }

  onSubmit() {
    debugger;
    this.dormitoryService.updateDormitory(this.dormitory).subscribe(
      (result) => {
        this.router.navigateByUrl("/dormitory-list");
      },
      (error) => console.error(error)
    );
  }

  ngOnInit(): void {
    this.sub = this.route.paramMap.subscribe((params) => {
      const id = +params.get("id");
      this.getDormitory(id);
    });
  }
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
