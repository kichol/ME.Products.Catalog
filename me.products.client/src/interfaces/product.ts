export interface Product {
        productId: string,
        code: string,
        name: string,
        price: number
}



export interface ProductListResponse {
        products: Product[],
        totalCount: number
    
    }