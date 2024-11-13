export interface IOrderViewModel {
    id:number,
    statusId:number,
    totalAmount:number,
    items:IOrderViewModel[]
}
