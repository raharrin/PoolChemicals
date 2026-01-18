<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="PoolChemicals.MainPage"
             xmlns:viewmodel="clr-namespace:PoolChemicals.ViewModel"
             x:DataType="viewmodel:MainViewModel">

    <ScrollView>
        <VerticalStackLayout>
            <HorizontalStackLayout Padding="5">
                <Label Text="Pool Volume: " 
                       FontSize="15"
                       FontAttributes="Bold"
                       VerticalTextAlignment="Center" />
                <Entry Keyboard="Numeric" 
                       MaxLength="6"
                       FontSize="15"
                       FontAttributes="Bold"
                       Text="{Binding Volume}"
                       ReturnCommand="{Binding CalculateAllCommand}"/>
                <Label Text="{Binding SizeUnit,StringFormat=' {0}'}" 
                       VerticalTextAlignment="Center"
                       FontSize="15"
                       FontAttributes="Bold"/>
            </HorizontalStackLayout>
            <HorizontalStackLayout Padding="5">
                <Label Text="Water Tempurature: "
                       VerticalTextAlignment="Center"
                       FontSize="15"
                       FontAttributes="Bold"/>

                <Entry Keyboard="Numeric" MaxLength="2"
                       Text="{Binding WaterTemp}"
                       FontSize="15"
                       FontAttributes="Bold"
                       ReturnCommand="{Binding EnterWaterTempCommand}"/>
                <Label Text="{Binding TempUnit}"
                       VerticalTextAlignment="Center"
                       FontSize="15"
                       FontAttributes="Bold"/>

            </HorizontalStackLayout>

            <!-- CSI Grid-->
            <Grid Padding="0,5">
                <Border Stroke="Black" Margin="5,0,5,0"
                        BackgroundColor="LightPink">
                    <Grid ColumnDefinitions="70,60,20,*"
                          RowDefinitions="*,*,*,*"
                          Padding="10">
                        <Label Text="Range: -0.5 to 0.5"                                                             
                               Grid.ColumnSpan="5"
                               FontSize="15"
                               FontAttributes="Bold"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"/>

                        <Label Text="CSI"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="0"/>

                        <Label Text="Current: "
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="1"/>
                        <Label  FontSize="15" FontAttributes="Bold"
                                HorizontalTextAlignment="Center" 
                                VerticalTextAlignment="Center"
                                Text="{Binding SaturationIndex}" 
                                Grid.Row="1" Grid.Column="2" />
                            <Label Text="{Binding SaturationIndexTarget,StringFormat='Target: {0}'}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="3"/>
                        <!--<Label Text="{Binding SaturationIndexTarget}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold,Italic"
                               Grid.Row="1" Grid.Column="4"/>-->
                        <Label Text="Calcite Saturation Index - requires pH, TA, CH, CYA, Temp, uses Borate, Salt
Less than -0.6 is suggestive of problems for plaster, tile, stone, and pebble pools.
Greater than 0.6 is suggestive of problems for all pools."
                               FontSize="15" 
                               FontAttributes="Bold"
                               Grid.Row="3" Grid.Column="0"  
                               Grid.ColumnSpan="5"/>
                    </Grid>
                </Border>
            </Grid>

            <!-- Salt Grid-->
            <Grid Padding="0,5">
                <Border Stroke="Black" Margin="5,0,5,0">
                    <Grid ColumnDefinitions="70,*,*,*,*"
                          RowDefinitions="*,*,*"
                          Padding="10">
                        <Label Text="{Binding SaltRange}"                                                             
                               Grid.ColumnSpan="5"
                               FontSize="15"
                               FontAttributes="Bold"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"/>

                        <BoxView Grid.Row="1" Grid.Column="0"
                                 Grid.RowSpan="2"
                                 BackgroundColor="LightBlue" />
                        <Label Text="Salt"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="0"
                               Grid.RowSpan="2"/>
                        <BoxView Grid.Row="1" Grid.Column="1"
                                 BackgroundColor="LightBlue" />
                        <Label Text="Current"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="1"/>
                        <Entry  Keyboard="Numeric"
                                FontSize="15" FontAttributes="Bold"
                                HorizontalTextAlignment="Center" 
                                VerticalTextAlignment="Center"
                                Text="{Binding SaltReading}" 
                                MaxLength="4"
                                ReturnType="Next"
                                
                                Grid.Column="1" Grid.Row="2"               
                                ReturnCommand="{Binding EnterSaltCommand}"/>
                        <BoxView Grid.Row="1" Grid.Column="2"
                                 BackgroundColor="LightBlue" />
                        <Label Text="Target"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="2"/>
                        <BoxView Grid.Row="1" Grid.Column="3" Grid.ColumnSpan="2"
                                 BackgroundColor="LightBlue"/>
                        <Label Text="{Binding SaltTitle}"                               
                               IsVisible="{Binding SaltIsVisible}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="3" Grid.ColumnSpan="2"/>
                        <Label Text="{Binding SaltTarget}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold,Italic"
                               Grid.Row="2" Grid.Column="2"/>
                        <Label Text="{Binding SaltResults}"
                               IsVisible="{Binding SaltIsVisible}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold"
                               Grid.Row="2" Grid.Column="3"  Grid.ColumnSpan="{Binding SaltColumnSpan}"/>
                    </Grid>
                </Border>
            </Grid>
            <!-- FC Grid-->
            <Grid Padding="0,5">
                <Border Stroke="Black" Margin="5,0,5,0">
                    <Grid ColumnDefinitions="*,*,*,*,*"
                          RowDefinitions="*,*,*,*,*"
                          Padding="10" RowSpacing="0" ColumnSpacing="0">
                        <Label Text="{Binding FCRange}"
                               Grid.ColumnSpan="5"
                               FontSize="15"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"/>
                        <BoxView Grid.Row="1" Grid.Column="0"
                                 Grid.RowSpan="2" 
                                 BackgroundColor="Yellow"/>
                        <Label Text="FC"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="0"
                               Grid.RowSpan="2"/>
                        <BoxView Grid.Row="1" Grid.Column="1"
                                 BackgroundColor="Yellow" />
                        <Label x:Name="Label3" Text="Current"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="1"/>
                        <Entry  Keyboard="Numeric"
                                FontSize="15" FontAttributes="Bold"
                                HorizontalTextAlignment="Center"           
                                Text="{Binding FCReading}" 
                                MaxLength="1"
                                Grid.Column="1" Grid.Row="2"
                                ReturnCommand="{Binding EnterFCCommand}"/>
                        <BoxView Grid.Row="1" Grid.Column="2"
                                 BackgroundColor="Yellow" />
                        <Label Text="Target"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="2"/>
                        <BoxView Grid.Row="1" Grid.Column="3" Grid.ColumnSpan="2"
                                 BackgroundColor="Yellow"/>

                        <Label IsVisible="{Binding FCBIsVisible}"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="3" Grid.Column="0" Grid.ColumnSpan="5">
                            <Label.Text>
                                <MultiBinding StringFormat="Add {0}oz of {2}% Bleach">
                                    <Binding Path="AddBleach"/>
                                    <Binding Path="AddBleach"/>
                                    <Binding Path="Bleach"/>
                                </MultiBinding>
                            </Label.Text>
                        </Label>
                        <Label IsVisible="{Binding FCCIsVisible}"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="3" Grid.Column="0" Grid.ColumnSpan="5">
                            <Label.Text>
                                <MultiBinding StringFormat="Add {0}oz by weight or {1}oz by volume of {2}.">
                                    <Binding Path="ByWeight"/>
                                    <Binding Path="ByVolume"/>
                                    <Binding Path="ChlorinePickerSelection"/>
                                </MultiBinding>
                            </Label.Text>
                        </Label>
                        <Label IsVisible="{Binding FCNoteIsVisible}"
                               Text="Note: Dichlor and trichlor increses CYA and lower pH. Cal-hypo adds Calcium."
                                 FontSize="15" FontAttributes="Bold"
                               Grid.Row="5" Grid.Column="0" Grid.ColumnSpan="5"/>


                        <Label Text="{Binding FCTarget}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold,Italic"
                               Grid.Row="2" Grid.Column="2"/>
                        <!--<Label Text="{Binding AddBleach}"
                               IsVisible="{Binding FCIsVisible}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold"
                               Grid.Row="2" Grid.Column="3"/>
                        <Label Text="oz"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold"
                               Grid.Row="2" Grid.Column="4"
                               IsVisible="{Binding FCIsVisible}"/>-->
                    </Grid>
                </Border>
            </Grid>

            <!-- pH Grid-->
            <Grid Padding="0,5">
                <Border Stroke="Black">
                    <Grid ColumnDefinitions="*,*,*,*,*"
                          RowDefinitions="*,*,*"
                          Padding="10" RowSpacing="0" ColumnSpacing="0">
                        <Label Text="{Binding PHRange}"
                               Grid.ColumnSpan="5"
                               FontSize="15"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"/>
                        <BoxView Grid.Row="1" Grid.Column="0"
                                 Grid.RowSpan="2" 
                                 BackgroundColor="Orange"/>
                        <Label Text="pH"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="0"
                               Grid.RowSpan="2"/>
                        <BoxView Grid.Row="1" Grid.Column="1"
                                 BackgroundColor="Orange" />
                        <Label Text="Current"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="1"/>
                        <Entry  Keyboard="Numeric"
                                FontSize="15" FontAttributes="Bold"
                                HorizontalTextAlignment="Center"
                                MaxLength="3"
                                Text="{Binding PHReading}" 
                                Grid.Column="1" Grid.Row="2"  
                                ReturnCommand="{Binding EnterPHCommand}"/>
                        <BoxView Grid.Row="1" Grid.Column="2"
                                 BackgroundColor="Orange" />
                        <Label Text="Target"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="2" />
                        <BoxView Grid.Row="1" Grid.Column="3" Grid.ColumnSpan="2"
                                 BackgroundColor="Orange"/>
                        <Label Text="{Binding AcidSoda}"
                               IsVisible="{Binding PHIsVisible}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="3" Grid.ColumnSpan="2"/>
                        <Label Text="{Binding PHTarget}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold,Italic"
                               Grid.Row="2" Grid.Column="2"/>
                        <Label Text="{Binding AcidSodaAdd}"
                               IsVisible="{Binding PHIsVisible}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold"
                               Grid.Row="2" Grid.Column="3" />

                        <Picker x:Name="PHPickerList"
                                Title="Choose"
                                FontAttributes="Bold"
                                IsVisible="{Binding PHIsVisible}"  
                                Grid.Row="2" Grid.Column="4" 
                                SelectedItem="{Binding PHPickerSelection}"
                                SelectedIndex="{Binding PHPicker}"/>
                        
                    </Grid>
                </Border>
            </Grid>

            <!-- Alkaline Grid-->
            <Grid Padding="0,5">
                <Border Stroke="Black">
                    <Grid ColumnDefinitions="*,*,*,*,*"
                          RowDefinitions="*,*,*"
                          Padding="10" RowSpacing="0" ColumnSpacing="0">
                        <Label Text="{Binding AlkalineRange}"
                               Grid.ColumnSpan="5"
                               FontSize="15"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"/>
                        <BoxView Grid.Row="1" Grid.Column="0"
                                 Grid.RowSpan="2" 
                                 BackgroundColor="LightGreen"/>
                        <Label Text="Alkaline"
                                   HorizontalTextAlignment="Center"
                                   VerticalTextAlignment="Center"
                                   FontSize="15" FontAttributes="Bold"
                                   Grid.Row="1" Grid.Column="0"
                                   Grid.RowSpan="2"/>
                        <BoxView Grid.Row="1" Grid.Column="1"
                                 BackgroundColor="LightGreen" />
                        <Label Text="Current"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="1"/>
                        <Entry  Keyboard="Numeric"
                                FontSize="15" FontAttributes="Bold"
                                HorizontalTextAlignment="Center"
                                MaxLength="3"
                                Text="{Binding AlkalineReading}" 
                                Grid.Column="1" Grid.Row="2"                
                                ReturnCommand="{Binding EnterAlkalineCommand}"/>
                        <BoxView Grid.Row="1" Grid.Column="2"
                                 BackgroundColor="LightGreen" />
                        <Label Text="Target"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="2"/>
                        <BoxView Grid.Row="1" Grid.Column="3" Grid.ColumnSpan="2"
                                 BackgroundColor="LightGreen"/>
                        <Label Text="{Binding AcidSodaAlk}"
                               IsVisible="{Binding AlkalineIsVisible}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="3" Grid.ColumnSpan="2"/>
                        <Label Text="{Binding AlkalineTarget}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold,Italic"
                               Grid.Row="2" Grid.Column="2"/>
                        <Label Text="{Binding AcidSodaAlkAdd}"
                               IsVisible="{Binding AlkalineIsVisible}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold"
                               Grid.Row="2" Grid.Column="3"/>

                        <Picker x:Name="AlkalinePickerList"
                             Title="Choose"
                             FontAttributes="Bold"
                             IsVisible="{Binding AlkalineIsVisible}"  
                             Grid.Row="2" Grid.Column="4" 
                             SelectedItem="{Binding AlkalinePickerSelection}"
                             SelectedIndex="{Binding AlkalinePicker}"/>      
                    </Grid>
                </Border>
            </Grid>

            <!-- Calcium Grid-->
            <Grid Padding="0,5">
                <Border Stroke="Black">
                    <Grid ColumnDefinitions="*,*,*,*,*"
                          RowDefinitions="*,*,*"
                          Padding="10" RowSpacing="0" ColumnSpacing="0">
                        <Label Text="{Binding CalciumRange}"
                               Grid.ColumnSpan="5"
                               FontSize="15"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"/>
                        <BoxView Grid.Row="1" Grid.Column="0"
                                 Grid.RowSpan="2" 
                                 BackgroundColor="MediumPurple"/>
                        <Label Text="Calcium"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="0"
                               Grid.RowSpan="2"/>
                        <BoxView Grid.Row="1" Grid.Column="1"
                                 BackgroundColor="MediumPurple" />
                        <Label Text="Current"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="1"/>
                        <Entry  Keyboard="Numeric"
                               FontSize="15" FontAttributes="Bold"
                               HorizontalTextAlignment="Center"
                               MaxLength="3"
                               Text="{Binding CalciumReading}" 
                               Grid.Column="1" Grid.Row="2"                
                               ReturnCommand="{Binding EnterCalciumCommand}"/>
                        <BoxView Grid.Row="1" Grid.Column="2"
                                 BackgroundColor="MediumPurple" />
                        <Label Text="Target"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="2"/>
                        <BoxView Grid.Row="1" Grid.Column="3" Grid.ColumnSpan="2"
                                 BackgroundColor="MediumPurple"/>
                        <Label Text="{Binding CalciumTitle}"
                               IsVisible="{Binding CalciumIsVisible}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="3" Grid.ColumnSpan="2"/>
                        <Label Text="{Binding CalciumTarget}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold,Italic"
                               Grid.Row="2" Grid.Column="2"/>
                        <Label Text="{Binding CalciumResults}"
                               IsVisible="{Binding CalciumIsVisible}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold"
                               Grid.Row="2" Grid.Column="3" Grid.ColumnSpan="{Binding CalciumResultsSpan}" />
                        <Picker x:Name="CalciumPicker"
                                Title="Choose"
                                FontAttributes="Bold"
                                IsVisible="{Binding CalciumPickerIsVisible}"  
                                Grid.Row="2" Grid.Column="4" 
                                SelectedItem="{Binding CalciumPickerSelection}">
                            <Picker.Items>
                                <x:String>oz</x:String>
                                <x:String>lbs</x:String>
                            </Picker.Items>

                        </Picker>
                        <!--<Label Text="oz"
                               IsVisible="{Binding CalciumIsVisible}"                               
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold"
                               Grid.Row="2" Grid.Column="4"/>-->
                    </Grid>
                </Border>
            </Grid>

            <!-- CYA Grid-->
            <Grid Padding="0,5">
                <Border Stroke="Black">
                    <Grid ColumnDefinitions="*,*,*,*,*"
                          RowDefinitions="*,*,*"
                          Padding="10" RowSpacing="0" ColumnSpacing="0">
                        <Label Text="{Binding CYARange}"
                               Grid.ColumnSpan="5"
                               FontSize="15"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"/>
                        <BoxView Grid.Row="1" Grid.Column="0"
                                 Grid.RowSpan="2" 
                                 BackgroundColor="Cyan"/>
                        <Label Text="CYA"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="0"
                               Grid.RowSpan="2"/>
                        <BoxView Grid.Row="1" Grid.Column="1"
                                 BackgroundColor="Cyan" />
                        <Label Text="Current"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="1"/>
                        <Entry  Keyboard="Numeric"
                               FontSize="15" FontAttributes="Bold"
                               HorizontalTextAlignment="Center"
                               MaxLength="2"
                               Text="{Binding CYAReading}" 
                               Grid.Column="1" Grid.Row="2"                
                               ReturnCommand="{Binding EnterCYACommand}"/>
                        <BoxView Grid.Row="1" Grid.Column="2"
                                 BackgroundColor="Cyan" />
                        <Label Text="Target"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="2"/>
                        <BoxView Grid.Row="1" Grid.Column="3" Grid.ColumnSpan="2"
                                 BackgroundColor="Cyan"/>
                        <Label Text="{Binding CYATitle}"
                               IsVisible="{Binding CYAIsVisible}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="3" Grid.ColumnSpan="2"/>
                        <Label Text="{Binding CYATarget}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold,Italic"
                               Grid.Row="2" Grid.Column="2"/>
                        <Label Text="{Binding CYAStabilizer}"
                               IsVisible="{Binding CYAIsVisible}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold"
                               Grid.Row="2" Grid.Column="3"/>
                        <Label Text="oz"
                               IsVisible="{Binding CYAIsVisible}"                               
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold"
                               Grid.Row="2" Grid.Column="4"/>
                    </Grid>
                </Border>
            </Grid>

            <!-- Borate Grid-->
            <Grid Padding="0,5">
                <Border Stroke="Black">
                    <Grid ColumnDefinitions="*,*,*,*,*"
                          RowDefinitions="*,*,*"
                          Padding="10" RowSpacing="0" ColumnSpacing="0">
                        <Label Text="{Binding BorateRange}"
                               Grid.ColumnSpan="5"
                               FontSize="15"
                               FontAttributes="Bold"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"/>
                        <BoxView Grid.Row="1" Grid.Column="0"
                                 Grid.RowSpan="2" 
                                 BackgroundColor="LightGray"/>
                        <Label Text="CYA"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="0"
                               Grid.RowSpan="2"/>
                        <BoxView Grid.Row="1" Grid.Column="1"
                                 BackgroundColor="LightGray" />
                        <Label Text="Current"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="1"/>
                        <Entry  Keyboard="Numeric"
                               FontSize="15" FontAttributes="Bold"
                               HorizontalTextAlignment="Center"
                               MaxLength="2"
                               Text="{Binding BorateReading}" 
                               Grid.Column="1" Grid.Row="2"                
                               ReturnCommand="{Binding EnterBorateCommand}"/>
                        <BoxView Grid.Row="1" Grid.Column="2"
                                 BackgroundColor="LightGray" />
                        <Label Text="Target"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="2"/>
                        <BoxView Grid.Row="1" Grid.Column="3" Grid.ColumnSpan="2"
                                 BackgroundColor="LightGray"/>
                        <Label Text="{Binding BorateTitle}"
                               IsVisible="{Binding BorateIsVisible}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" FontAttributes="Bold"
                               Grid.Row="1" Grid.Column="3" Grid.ColumnSpan="2"/>
                        <Label Text="{Binding BorateTarget}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold,Italic"
                               Grid.Row="2" Grid.Column="2"/>
                        <Label Text="Filler"
                               IsVisible="{Binding BorateIsVisible}"
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold"
                               Grid.Row="2" Grid.Column="3"/>
                        <Label Text="oz"
                               IsVisible="{Binding BorateIsVisible}"                               
                               HorizontalTextAlignment="Center"
                               VerticalTextAlignment="Center"
                               FontSize="15" 
                               FontAttributes="Bold"
                               Grid.Row="2" Grid.Column="4"/>
                    </Grid>
                </Border>
            </Grid>

            <Button Text="Water Guidlines" 
                    FontSize="15" FontAttributes="Bold"
                    BackgroundColor="Blue"
                    Command="{Binding x:DataType='viewmodel:MainViewModel', Source={RelativeSource AncestorType={x:Type viewmodel:MainViewModel}}, Path=WaterGuidelinesCommand}"/>
            <Button Text="Settings" 
                    FontSize="15" FontAttributes="Bold"
                    BackgroundColor="Blue"
                    Command="{Binding Source={RelativeSource AncestorType={x:Type viewmodel:BaseViewModel}}, Path=TargetsCommand}"/>

            <!--Command="{Binding x:DataType='viewmodel:MainViewModel', Source={RelativeSource AncestorType={x:Type viewmodel:BaseViewModel}}, Path=TargetsCommand}"/>-->
        </VerticalStackLayout>
    </ScrollView>
</ContentPage>




