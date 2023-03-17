export class ResponseModel<T> {
    isSuccess!:boolean;
    message!  :string;
    result!   :T;
}