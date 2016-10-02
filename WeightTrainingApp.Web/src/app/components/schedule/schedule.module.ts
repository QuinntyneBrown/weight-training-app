import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DayPickerComponent } from "./day-picker.component";
import { ScheduleComponent } from "./schedule.component";
import { ScheduledItemsComponent } from "./scheduled-items.component";

const declarables = [
    DayPickerComponent,
    ScheduleComponent,
    ScheduledItemsComponent
];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables]
})
export class ScheduleModule { }
