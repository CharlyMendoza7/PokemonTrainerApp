import { useEffect, useState } from "react"

export const HomePage = () => {

    const [user, setuser] = useState<string | null>(null);

    useEffect(() => {
        const userName = localStorage.getItem('user')
        if (userName) {
            setuser(userName);
        }


    }, [])



    return (
        <div>Welcome {user}</div>
    )
}
