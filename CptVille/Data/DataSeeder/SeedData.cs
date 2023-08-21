using CptVille.Models;

namespace CptVille.Data.DataSeeder
{
    public static class SeedData
    {
        public static void Seeding(IApplicationBuilder applicationBuilder)
        {
            using(var scope = applicationBuilder.ApplicationServices.CreateScope()) {
                var _context = scope.ServiceProvider.GetService<VilleContext>();
                _context.Database.EnsureCreated();
                if(!_context.Sections.Any())
                {
                    var sections = new List<Section>()
                    {
                        new Section() { Name ="إقليم تطوان" },
                        new Section() { Name ="المجلس الإقليمي" },
                        new Section() { Name ="مشاريع و منجزات" },
                        new Section() { Name ="إعلانات" },
                        new Section() { Name ="إتصل بنا" }
                    };
                    _context.Sections.AddRange(sections);
                    _context.SaveChanges();
                }
                if(!_context.UnderSections.Any())
                {
                    var first = _context.Sections.First();
                    var all = _context.Sections.ToList();
                    var second = all[1];
                    var underSections = new List<UnderSection>()
                    {
                        new UnderSection() { Name ="بطاقة تعريفية للإقليم",MainSectionId = first.Id },
                        new UnderSection() { Name ="معطيات ديموغرافية",MainSectionId = first.Id },
                        new UnderSection() { Name ="معطيات حول الوسط الطبيعي",MainSectionId = first.Id },
                        new UnderSection() { Name ="المجال الإقتصادي",MainSectionId = first.Id },

                        new UnderSection() { Name ="كلمة الرئيس",MainSectionId = second.Id },
                        new UnderSection() { Name ="لجان المجلس",MainSectionId = second.Id },
                        new UnderSection() { Name ="أنشطة المجلس",MainSectionId = second.Id }
                    };
                    _context.UnderSections.AddRange(underSections);
                    _context.SaveChanges();
                }
                if (!_context.Blogs.Any())
                {

                    var first = _context.UnderSections.First();
                    var blogs = new List<Blog>()
                    {
                        new Blog()
                        {
                            Title = "رئيس مجلس إقليم تطوان السيد ابراهيم بنصبيح يحضر حفل تنصيب رجال السلطة الجدد الذين تم تعيينهم مؤخرا بالإقليم",
                            Description = "حضر، السيد إبراهيم بنصبيح؛ رئيس مجلس إقليم تطوان يومه الأربعاء 16 غشت 2023 بمقر عمالة إقليم تطوان ، حفل تنصيب رجال السلطة الجدد الذين تم تعيينهم مؤخرا بالإقليم في إطار الحركة الانتقالية التي أجرتها وزارة الداخلية، من أجل ضخ دماء جديدة في سلك الإدارة الترابية بالإقليم.\r\n\r\nوجرى خلال هذا الحفل، الذي ترأسته عامل إقليم تطوان ؛ السيد يونس التازي الذي كان مرفوقا بالسيد الكاتب العام للعمالة والسيد رئيس الشؤون الداخلية بالعاملة وحضره ممثلي السلطات الأمنية و القضائية ونواب ومستشارو الإقليم في البرلمان ورؤساء المصالح الأمنية ورؤساء المصالح الخارجية الإقليمية ورؤساء الجماعات الترابية وممثلي جمعيات المجتمع المدني وممثلي وسائل الإعلام الوطنية والمحلية.\r\n\r\nتعيين السيد رسيد أزواغ بمنصب باشا مدينة تطوان، السيد محسن شتوي بمنصب رئيس دائرة جبالة ،السيد عبدالرحمان الكبير بمنصب رئيس منطقة سيدي المنظري ، السيد محمد عماري مديرا للحي الجامعي (رتبة رئيس دائرة)، السيد رضوان دحار بمنصب قائد بني يدر ،السيد رضوان فكري بمنصب قائد أزلا زيتون، السيد ياسين نور سعيد بمنصب قائد بني سعيد ، السيد طه التكموتي بمنصب قائد جبل الحبيب ، السيد خالد التابدي بمنصب قائد عين الحصن ، السيد عثمان بوسعيد بمنصب قائد الملحقة الإدارية سمسة ،السيد وائل كرداد بمنصب قائد الملحقة الإدارية حي المدرسي ،السيد جمال المدني بمنصب قائد الملحقة الإدارية درسة ، السيد عمر العسري بمنصب قائد الملحقة الإدارية المطار ، السيد ياسين شوقي بمنصب قائد الملحقة الإدارية المصلى ،السيد محمد النحير بمنصب قائد نائب شؤون الداخلية والسيد معاد بوطربوش بمنصب قائد بالملحقة الإدارية طابولة.",
                            CreationDate = DateTime.Now,
                            UnderSectionId = first.Id
                        },
                        new Blog()
                        {
                            Title = "رئيس المجلس الإقليمي لتطوان يهنئ جلالة الملك بذكرى ثورة الملك والشعب وعيد الشباب",
                            Description = "صاحب الجلالة الملك محمد السادس نصره الله وأيده\r\nبأحر التهاني وأصدق آيات الولاء والإخلاص، متمنين لجلالته موفور الصحة و العافية، سائلين العلي جلت قدرته أن يبارك في عمر جلالته و يقر عينه بسمو ولي عهده المحبوب صاحب السمو الملكي الأمير مولاي الحسن و بكريمة جلالته المصون صاحبة السمو الملكي الأميرة لالة خديجة، و أن يشد أزره بشقيقه صاحب السمو الملكي الأمير مولاي رشيد و بكافة أفراد الأسرة الملكية الشريفة.",
                            CreationDate = DateTime.Now,
                            UnderSectionId = first.Id
                        },
                        new Blog()
                        {
                            Title = "تهنئة بمناسبة إعلان نتائج البكالوريا 2023",
                            Description = "بمناسبة إعلان نتائج البكالوريا ” الدورة العادية يونيو 2023 “، يطيب لرئيس مجلس إقليم تطوان، السيد إبراهيم بنصبيح، أن يتقدم إلى كافة الناجحات والناجحين بأخلص عبارة التهنئة، متمنيا لهم مزيدا من النجاحات في المستقبل ، ويتمنى لكل من لم يتمكن من النجاح في هذه الدورة الحظ الأوفر والتوفيق في الدورة الاستداركية.",
                            CreationDate = DateTime.Now,
                            UnderSectionId = first.Id
                        },

                    };
                    _context.Blogs.AddRange(blogs); 
                    _context.SaveChanges();
                }
                if (!_context.Achievements.Any())
                {
                    var achievements = new List<Achievement>()
                    {
                        new Achievement(){Name ="الكل"},
                        new Achievement(){Name = "الرياضة"},
                        new Achievement(){Name = "دعم المجال الإجتماعي"},
                        new Achievement(){Name = "البنية التحتية"},
                        new Achievement(){Name = "البنية التحتية"}
                    };
                    _context.Achievements.AddRange(achievements);
                    _context.SaveChanges();
                }
            }
        }
    }
}
