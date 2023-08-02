export interface IMenu {
    descricao: string,
    icone: string,
    routerLink?: string;
    children?: IMenuItem[]
}
export interface IMenuItem {
    descricao: string,
    icone: string,
    routerLink: string;
}