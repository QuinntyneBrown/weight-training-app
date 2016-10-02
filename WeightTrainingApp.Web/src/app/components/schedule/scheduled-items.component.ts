import { Component, Input } from "@angular/core";

@Component({
    template: require("./scheduled-items.component.html"),
    styles: [require("./scheduled-items.component.scss")],
    selector: "scheduled-items"
})
export class ScheduledItemsComponent { 
    private _scheduledItems: Array<any>;
    private _currentIndex: number;

    @Input('scheduledItems') public set scheduledItems(value) { this._scheduledItems = value; }

    public get scheduledItems() {
        return this._scheduledItems.filter(s => s.date == this.days[this._currentIndex].date);         
    }

    @Input() days: Array<any> = [];
    @Input("currentIndex") public set currentIndex(value) { this._currentIndex = value; }
}
