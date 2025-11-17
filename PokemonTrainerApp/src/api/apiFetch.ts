import { getToken } from "../utils/authUtils";

export async function apiFetch<TResponse>(
    url: string,
    options: RequestInit = {}
): Promise<TResponse> {


    const token = getToken();

    const headers = new Headers(options.headers || {});

    if (token) {
        headers.set("Authorization", `Bearer ${token}`);
    }

    headers.set("Content-Type", "application/json");

    const response = await fetch(url, {
        ...options,
        headers,
    });

    //LOGOUT IF UNAURHOTIZED
    // if(response.status === 401){

    // }

    if (!response.ok) {
        throw new Error(`API Error: ${response.status}`);
    }

    return await response.json();

}