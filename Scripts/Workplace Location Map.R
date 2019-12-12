# Get a list of previous contract locations

library(dplyr)
library(ggplot2)
library(ggmap)

options(pillar.sigfig=8)
#get_postcode_locations(c("OX1 1HS"))

# Oxford rail station - OX1 1HS
home <- tribble(
    ~lat, ~long,
    #--|--|----
    51.753427, -1.270078
)

# Canary Wharf E14 -  51.5061215883373, -0.0186463065819861 (from pi.postcodes.io/outcodes/E14)
# # Bedford iLab - MK44 3RZ 
# Coventry CV1 2WT
# Wildnet EC3V 9BQ
# Battersea near SW11 4AN
# Conde Naste W1S 1JU
# Clapham South near SW12 9DY
# Dukes Court GU21 5BH
# Chancery Lane WC2A 1E


#source("Postcode Functions.R")
#locations <- get_postcode_locations(c("MK44 3RZ", "EC3V 9BQ", "SW11 4AN", "W1S 1JU", "SW12 9DY", "GU21 5BH", "WC2A 1E", "CV1 2WT"))
#locations %>% select(latitude, longitude, postcode)
#locations1 <- locations

#locations <- locations %>% 
#  select(latitude, longitude, postcode) %>% 
#  bind_rows(list(latitude = 51.5061215883373, longitude = -0.0186463065819861, postcode = "Canary Wharf"))

# Or do it by hand:

locations <- tribble(
  ~lat, ~long,
  #--|--|----
  
  51.5061215883373, -0.0186463065819861, # 'Canary Wharf'
  52.125775,  -0.420005,  #MK44 3RZ
  51.511867, -0.085949,   #EC3V 9BQ
  51.479629, -0.169863,   #SW11 4AN
  51.513388, -0.143087,   #W1S 1JU 
  51.452448, -0.147187,   #SW12 9DY
  51.320681, -0.554201,   #GU21 5BH
  52.400997, -1.508122   #CV1 2WT 
)


home
locations

(combined_locations <- locations %>% 
    mutate(home_lat = home$lat,
           home_long = home$long)
)



ggplot(locations, aes(x = long, y = lat)) +
  geom_point(data = home, col = "red") +
  geom_point(col = "green") +
  geom_segment(data = combined_locations, 
               aes(x = home_long, y = home_lat, xend = long, yend = lat),
               arrow=arrow(), size=2, color="blue")

bbox <- c(left = -2.0, bottom = 51.0, right = 0.8, top = 52.6)

get_stamenmap(bbox, maptype = "watercolor") %>% 
  ggmap() +
  geom_point(data = home, aes(x = long, y = lat), col = "red") +
  geom_point(data = locations, aes(x = long, y = lat), col = "green") +
  geom_segment(data = combined_locations, 
               aes(x = home_long, y = home_lat, xend = long, yend = lat),
               arrow=arrow(), size=1, color="blue")

  
  



