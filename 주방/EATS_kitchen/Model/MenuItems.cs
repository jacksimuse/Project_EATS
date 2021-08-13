namespace kiosk1.Model
{
    public class MenuItems
    {
        public string MenuCode { get; set; }  // 20210813 성명건 추가
        public string MenuName { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public string ImageSrc { get; set; }
        public string ImageName { get; set; }
        public bool Activation { get; set; }

    }
}
