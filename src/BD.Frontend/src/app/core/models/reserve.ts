import { Item } from './item';

export class Reserve {
    id: number;
    price:number;
    entry: number;
    description: string;

    items: Item[];

    dateStart: Date;
    dateEnd: Date;
    disabledAt: Date;
}

export class ReserveSearch {
    minPrice:number;
    maxPrice:number;
    minEntry: number;
    maxEntry: number;
    minDateStart: Date;
    maxDateStart: Date;
    enabled: boolean;
}