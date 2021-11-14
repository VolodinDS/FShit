[<AbstractClass>]
type Jewerly(name, price) = class
    member val Name = name
    member val Price = price
end

type Ring(name, price, radius) = class
    inherit Jewerly(name, price)
    member val Radius = radius
end

type Earrings(name, price, weight) = class
    inherit Jewerly(name, price)
    member val Weight = weight
end

[<EntryPoint>]
let main argv =
    let shoes = Ring("Ring", 45000, 10)
    let food = Earrings("Earrings", 90000, 15)
    printf $"Ring: {shoes.Name} {shoes.Price}RUB {shoes.Radius}mm \n"
    printf $"Food info: {food.Name} {food.Price}RUB {food.Weight}g"
    0