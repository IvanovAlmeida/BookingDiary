export class Item {
    id: number;
    name: string;
    quantity: number;
    price: number;
    description: string;
}

export class ItemSearch {
    id: number;
    name: string;
    minQuantity: number;
    maxQuantity: number;
    minPrice: number;
    maxPrice: number;
    enabled: boolean;
}
