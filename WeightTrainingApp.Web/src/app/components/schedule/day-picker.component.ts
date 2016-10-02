import { Component, EventEmitter, Input, OnInit, Output, ElementRef, AfterViewInit } from "@angular/core";

@Component({
    template: require("./day-picker.component.html"),
    styles: [require("./day-picker.component.scss")],
    selector: "day-picker"
})
export class DayPickerComponent implements AfterViewInit { 
    constructor(private _elementRef: ElementRef) {}
    
    ngAfterViewInit() {
        this.moveTo(this._currentIndex);
        setTimeout(() => { this._viewPort.style["transition"] = "all 500ms"; }, 0);
    }

    @Input() public days: Array<{ dayOfWeek: string; date: string; }> = [];

    private _currentIndex: number;

    @Input("currentIndex") public set currentIndex(value) { this._currentIndex = value; }

    public get currentIndex() { return this._currentIndex; }
    
    private get _cellWidth() { return 85; }

    private get _cellsWidth() { return this._cellWidth * this.days.length; }

    private get _width() { return this._elementRef.nativeElement.getBoundingClientRect()["width"]; }
    
    @Output() public onDayPicked: EventEmitter<any> = new EventEmitter();
    
    public get endPosition() { return (this._width - (this.days.length * this._cellWidth)); }

    public onClick(index: number) {
        this._currentIndex = index;      
        this.moveTo(index); 
        this.onDayPicked.emit({
            index: index,
            day: this.days[index]
        });
    }
    
    public moveTo(index: number) {        
        let newPosition = (index * this._cellWidth) + (this._cellWidth / 2);
        let delta = (newPosition - (this._width / 2)) * -1;
        delta = delta > 0 ? 0 : delta;
        delta = delta < this.endPosition ? this.endPosition : delta;        
        this._viewPort.style["transform"] = `translateX(${delta}px)`;         
    }

    public onResize($event) { this.moveTo(this._currentIndex); }   

    public get _viewPort() { return this._elementRef.nativeElement.firstElementChild.firstElementChild; }
}