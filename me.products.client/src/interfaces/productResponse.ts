export interface ProductResponse {
    product:{   
       productId: string,
       code: string
       name: string
       price: number
    },
    message: string,
    validationErrors:string[]

}