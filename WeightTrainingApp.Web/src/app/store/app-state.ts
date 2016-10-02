import { Exercise } from "../models";

export interface AppState {
    exercises: Array<Exercise>;
	currentUser: any;
    isLoggedIn: boolean;
    token: string;
}
