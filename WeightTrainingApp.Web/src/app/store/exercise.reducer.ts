import { Action } from "@ngrx/store";
import { EXERCISE_ADD_SUCCESS, EXERCISE_GET_SUCCESS, EXERCISE_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { Exercise } from "../models";
import { addOrUpdate, pluckOut } from "ng2-utilities";

export const exercisesReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case EXERCISE_ADD_SUCCESS:
            var entities: Array<Exercise> = state.exercises;
            var entity: Exercise = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { exercises: entities });

        case EXERCISE_GET_SUCCESS:
            var entities: Array<Exercise> = state.exercises;
            var newOrExistingExercises: Array<Exercise> = action.payload;
            for (let i = 0; i < newOrExistingExercises.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingExercises[i] });
            }                                    
            return Object.assign({}, state, { exercises: entities });

        case EXERCISE_REMOVE_SUCCESS:
            var entities: Array<Exercise> = state.exercises;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { exercises: entities });

        default:
            return state;
    }
}

