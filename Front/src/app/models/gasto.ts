export class Gasto {
    constructor(
        public id: number,
        public item: string,
        public valor: number,
        public dataCompra: Date,
        public gastoTipoId: number){ }
}
