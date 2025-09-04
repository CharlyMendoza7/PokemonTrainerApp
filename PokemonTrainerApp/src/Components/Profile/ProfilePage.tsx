import { mockTrainerProfile } from "./mockProfile"


export const ProfilePage = () => {

    const { username, email, firstName, lastName, favorite } = mockTrainerProfile;

    return (
        <div>
            <h2>Trainer Profile</h2>
            <div>
                <p><strong>Username:</strong> {username}</p>
                <p><strong>Email:</strong> {email}</p>
                <p><strong>FirstName:</strong> {firstName}</p>
                <p><strong>LastName:</strong> {lastName}</p>
                <p><strong>Favorite:</strong> {favorite}</p>
            </div>
        </div>
    )
}
