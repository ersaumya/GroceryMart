export class CartItem
{
    CartItemId: number;
    Total: number;
    constructor(public ProductId: number, public Name: string, public UnitPrice: number, public Quantity: number) { }
}