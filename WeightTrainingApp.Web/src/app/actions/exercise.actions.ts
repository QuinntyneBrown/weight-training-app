import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { ExerciseService } from "../services";
import { AppState, AppStore } from "../store";
import { EXERCISE_ADD_SUCCESS, EXERCISE_GET_SUCCESS, EXERCISE_REMOVE_SUCCESS } from "../constants";
import { Exercise } from "../models";
import { Observable } from "rxjs";
import { guid } from "ng2-utilities";

@Injectable()
export class ExerciseActions {
    constructor(private _exerciseService: ExerciseService, private _store: AppStore) { }

    public add(exercise: Exercise) {
        const newGuid = guid();
        this._exerciseService.add(exercise)
            .subscribe(exercise => {
                this._store.dispatch({
                    type: EXERCISE_ADD_SUCCESS,
                    payload: exercise
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._exerciseService.get()
            .subscribe(exercises => {
                this._store.dispatch({
                    type: EXERCISE_GET_SUCCESS,
                    payload: exercises
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._exerciseService.remove({ id: options.id })
            .subscribe(exercise => {
                this._store.dispatch({
                    type: EXERCISE_REMOVE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._exerciseService.getById({ id: options.id })
            .subscribe(exercise => {
                this._store.dispatch({
                    type: EXERCISE_GET_SUCCESS,
                    payload: [exercise]
                });
                return true;
            });
    }
}
