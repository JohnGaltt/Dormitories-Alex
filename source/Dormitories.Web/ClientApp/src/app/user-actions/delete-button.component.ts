import { Component, Input, Inject, EventEmitter, Output } from "@angular/core";

@Component({
  selector: "app-delete-button",
  templateUrl: "./delete-button.component.html",
})
export class DeleteButtonComponent {
  @Input() elementId: number;
  @Output() removeClicked: EventEmitter<number> = new EventEmitter<number>();

  constructor() {}

  removeElement(): void {
    this.removeClicked.emit(this.elementId);
  }
}
