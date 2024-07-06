import axios from "axios";
import { UserModel } from "../models/User/UserModel";
import LoginModel from "../models/LogIn/LoginModel";
import CreateUserModel from "../models/User/CreateUserModel";
import AuthenticationResult from "../models/Authetication/AuthenticationResult";
import { MenuModel } from "../models/Menu/MenuModel";
import { RestaurantModel } from "../models/Restaurant/RestaurantModel";
import { CreateRestaurantModel } from "../models/Restaurant/CreateRestaurantModel";
import { FilterRestaurantModel } from "../models/Restaurant/FilterRestaurantModel";
import { UpdateRestaurantModel } from "../models/Restaurant/UpdateRestaurantModel";
import { MenuItemModel } from "../models/MenuItem/MenuItemModel";
import { CreateMenuItemModel } from "../models/MenuItem/CreateMenuItemModel";
import { ReservationModel } from "../models/Reservation/ReservationModel";
import { CreateReservationModel } from "../models/Reservation/CreateReservationModel";

var baseAddress: string = 'https://localhost:7000/api/v1';

//#region User

export async function getUser(): Promise<UserModel> {
    var request = await axios.get<UserModel>(`${baseAddress}/user`)
    return request.data;
}

export async function createUser(model: CreateUserModel): Promise<UserModel> {
    var request = await axios.post<UserModel>(`${baseAddress}/user`, model)
    return request.data;
}

//#endregion

//#region LogIn

var tokenKey: string = "token";

export function isAuthenticated(): boolean {
    const token = localStorage.getItem(tokenKey);
    if (token) {
        setAuthentication(token);
        return true;
    }
    return false;
}

export async function logIn(model: LoginModel): Promise<AuthenticationResult> {
    var request = await axios.post<AuthenticationResult>(`${baseAddress}/authentication`, model)
    var data = request.data
    const token = data.authorizationToken;
    localStorage.setItem(tokenKey, token);
     return data;  
}

export async function logOut(): Promise<void> {
    localStorage.removeItem(tokenKey);
}

function setAuthentication(token: string) : void{    
    axios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
}

//#endregion

//#region Restaurant

export async function getRestaurant(restaurantId: number): Promise<RestaurantModel>{
    var request = await axios.get<RestaurantModel>(`${baseAddress}/restaurant/${restaurantId}`)
    return request.data;
}

export async function createRestaurant(model: CreateRestaurantModel): Promise<RestaurantModel>{
    var request = await axios.post<RestaurantModel>(`${baseAddress}/restaurant`, model)
    return request.data;
}

export async function filterRestaurant(model: FilterRestaurantModel): Promise<RestaurantModel[]>{
    let queryString = model.getQueryString();
    var request = await axios.get<RestaurantModel[]>(`${baseAddress}/restaurant/filter${queryString}`)
    return request.data;
}

export async function updateRestaurant(id:number , model: UpdateRestaurantModel) : Promise<RestaurantModel>{
    var request = await axios.put<RestaurantModel>(`${baseAddress}/restaurant/${id}`, model)
    return request.data;
}

//#endregion

//#region Menu

export async function getMenu(menuId: number): Promise<MenuModel>{
    var request = await axios.get<MenuModel>(`${baseAddress}/menu/${menuId}`)
    return request.data;
}

export async function createMenu(model: MenuModel): Promise<MenuModel>{
    var request = await axios.post<MenuModel>(`${baseAddress}/menu`, model)
    return request.data;
}

export async function deleteMenu(menuId: number): Promise<MenuModel>{
    var request = await axios.delete<MenuModel>(`${baseAddress}/menu/${menuId}`)
    return request.data;
}

//#endregion

//#region MenuItem

export async function getMenuItem(menuId: number, menuItemId: number): Promise<MenuItemModel>{
    var request = await axios.get<MenuItemModel>(`${baseAddress}/menu/${menuId}/menuitem/${menuItemId}`)
    return request.data;
}

export async function createMenuItem(menuId: number, model: CreateMenuItemModel): Promise<MenuItemModel>{
    var request = await axios.post<MenuItemModel>(`${baseAddress}/menu/${menuId}/menuitem`, model)
    return request.data;
}

export async function deleteMenuItem(menuId:number, menuItemId: number): Promise<MenuItemModel>{
    var request = await axios.delete<MenuItemModel>(`${baseAddress}/menu/${menuId}/menuitem/${menuItemId}`)
    return request.data;
}

//#endregion

//#region Reservation

export async function getReservation(reservationId: number): Promise<ReservationModel>{
    var request = await axios.get<ReservationModel>(`${baseAddress}/reservation/${reservationId}`)
    return request.data;
}

export async function createReservation(model: CreateReservationModel): Promise<ReservationModel>{
    var request = await axios.post<ReservationModel>(`${baseAddress}/reservation`, model)
    return request.data;
}

export async function deleteReservation(reservationId: number): Promise<ReservationModel>{
    var request = await axios.delete<ReservationModel>(`${baseAddress}/reservation/${reservationId}`)
    return request.data;
}

//#endregion 