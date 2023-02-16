import { ForecastTimestamp } from "./forecastTimestamp";
import { Place } from "./place";

export interface Forecast {
    place: Place;
    forecastType: string;
    forecastCreationTimeUtc: string;
    forecastTimestamps: ForecastTimestamp[];
}
