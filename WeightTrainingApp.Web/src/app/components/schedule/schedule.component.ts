import { Component, ChangeDetectionStrategy, Input, OnInit, ViewChild } from "@angular/core";
import { DayPickerComponent } from "./day-picker.component";
import { ScheduledItemsComponent } from "./scheduled-items.component";

@Component({
    template: require("./schedule.component.html"),
    styles: [require("./schedule.component.scss")],
    selector: "schedule"
})
export class ScheduleComponent implements OnInit { 

    ngOnInit() { this._currentIndex = Math.floor(this.days.length / 2); }

    private _scheduledItems: Array<any> = [];

    private _currentIndex: number;

    public get currentIndex() { return this._currentIndex; }

    @Input() public days: Array<{ dayOfTheWeek: string, date: string }> = [];

    @Input('scheduledItems') public set scheduledItems(value) { this._scheduledItems = value; };

    public get scheduledItems() { return this._scheduledItems; }

    @Input() public title: string;

    @ViewChild(DayPickerComponent) dayPickerComponent: DayPickerComponent;

    @ViewChild(ScheduledItemsComponent) scheduledItemsComponent: ScheduledItemsComponent;

    public onDayPicked($event) {
        this._currentIndex = $event.index;
    }
}
