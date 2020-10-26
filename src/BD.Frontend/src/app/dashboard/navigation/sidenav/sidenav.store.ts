import { BehaviorSubject, Observable } from 'rxjs';
import { map } from "rxjs/operators";

export interface State {
    isCollapsed: boolean
}

const state : State = {
    isCollapsed: true
};

export class SidenavStore {
    private subject = new BehaviorSubject<State>(state);
    private store = this.subject.asObservable();

    get value() {
        return this.subject.value;
    }

    public isCollapsed() : Observable<boolean> {
        return this.store.pipe(map(store => store.isCollapsed))
    }

    public close() {
        this.subject.next({
            isCollapsed: true
        });
    }

    public toggle() {
        this.subject.next({
            isCollapsed: !this.value.isCollapsed
        });
    }
}