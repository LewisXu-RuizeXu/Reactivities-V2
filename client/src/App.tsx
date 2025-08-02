import { ListItem, ListItemText, Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState, Fragment } from "react";

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);
  
  useEffect(() => {
    axios.get<Activity[]>('https://localhost:5001/api/activities')
    .then(response => setActivities(response.data))

    return () => {}
  }, [])

  return (
      <Fragment>
      <Typography variant ='h3' >Reactivities</Typography>
      <ul>
        {activities.map((activity) =>(
          <ListItem key={activity.id}>
            <ListItemText>{activity.title}</ListItemText>
          </ListItem>
        ))}
      </ul>
      </Fragment>
  )
}

export default App
